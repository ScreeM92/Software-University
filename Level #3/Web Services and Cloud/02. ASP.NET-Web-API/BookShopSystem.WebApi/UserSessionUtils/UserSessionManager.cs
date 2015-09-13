﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShopSystem.WebApi.UserSessionUtils
{
    using System.Xml.Linq;
    using BookShopSystem.Models;
    using Data;
    using Microsoft.AspNet.Identity;
    using Microsoft.Owin;

    public class UserSessionManager
    {
        private static readonly TimeSpan DefaultSessionTimeout = new TimeSpan(0, 0, 30, 0);

        protected IOwinContext OwinContext { get; set; }
        protected BookShopContext Data { get; private set; }

        public UserSessionManager(IOwinContext owinContext)
            : this(owinContext, new BookShopContext())
        {
        }

        public UserSessionManager(IOwinContext owinContext, BookShopContext data)
        {
            this.Data = data;
            this.OwinContext = owinContext;
        }

        /// <returns>The current bearer authorization token from the HTTP headers</returns>
        private string GetCurrentBearerAuthrorizationToken()
        {
            string authToken = null;
            if (this.OwinContext.Request.Headers["Authorization"] != null)
            {
                authToken = this.OwinContext.Request.Headers["Authorization"];
            }

            return authToken;
        }

        private string GetCurrentUserId()
        {
            if (this.OwinContext.Authentication.User.Identity == null)
            {
                return null;
            }

            return this.OwinContext.Authentication.User.Identity.GetUserId();
        }

        /// <summary>
        /// Extends the validity period of the current user's session in the database.
        /// This will configure the user's bearer authorization token to expire after
        /// certain period of time (e.g. 30 minutes, see UserSessionTimeout in Web.config)
        /// </summary>
        public void CreateUserSession(string username, string authToken)
        {
            var userId = this.Data.Users.First(u => u.UserName == username).Id;
            var userSession = new UserSession()
            {
                OwnerUserId = userId,
                AuthToken = authToken
            };
            this.Data.UserSessions.Add(userSession);

            // Extend the lifetime of the current user's session: current moment + fixed timeout
            userSession.ExpirationDateTime = DateTime.Now + DefaultSessionTimeout;
            this.Data.SaveChanges();
        }

        /// <summary>
        /// Makes the current user session invalid (deletes the session token from the user sessions).
        /// The goal is to revoke any further access with the same authorization bearer token.
        /// Typically this method is called at "logout".
        /// </summary>
        public void InvalidateUserSession()
        {
            string authToken = this.GetCurrentBearerAuthrorizationToken();
            if (authToken != null)
            {
                authToken = authToken.Substring(7);
            }

            var currentUserId = this.GetCurrentUserId();
            var userSession = this.Data.UserSessions.FirstOrDefault(session =>
                session.AuthToken == authToken && session.OwnerUserId == currentUserId);
            if (userSession != null)
            {
                this.Data.UserSessions.Remove(userSession);
                this.Data.SaveChanges();
            }
        }

        /// <summary>
        /// Re-validates the user session. Usually called at each authorization request.
        /// If the session is not expired, extends it lifetime and returns true.
        /// If the session is expired or does not exist, return false.
        /// </summary>
        /// <returns>true if the session is valid</returns>
        public bool ReValidateSession()
        {
            string authToken = this.GetCurrentBearerAuthrorizationToken();
            if (authToken != null)
            {
                authToken = authToken.Substring(7);
            }

            var currentUserId = this.GetCurrentUserId();
            var userSession = this.Data.UserSessions
                .FirstOrDefault(session => session.AuthToken == authToken && session.OwnerUserId == currentUserId);

            if (userSession == null)
            {
                // User does not have a session with this token --> invalid session
                return false;
            }

            if (userSession.ExpirationDateTime < DateTime.Now)
            {
                // User's session is expired --> invalid session
                return false;
            }

            // Extend the lifetime of the current user's session: current moment + fixed timeout
            userSession.ExpirationDateTime = DateTime.Now + DefaultSessionTimeout;
            this.Data.SaveChanges();

            return true;
        }

        public void DeleteExpiredSessions()
        {
            var userSessions = this.Data.UserSessions
                .Where(session => session.ExpirationDateTime < DateTime.Now);

            foreach (var userSession in userSessions)
            {
                this.Data.UserSessions.Remove(userSession);
            }

            this.Data.SaveChanges();
        }
    }
}