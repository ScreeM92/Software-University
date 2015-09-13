Parse.Cloud.afterSave(Parse.User, function(request) {
Parse.Cloud.useMasterKey();  

  query = new Parse.Query(Parse.Role);
  query.equalTo("name", "Member");
  query.first ( {
    success: function(object) {
      object.relation("users").add(request.user);

      object.save();
    },
    error: function(error) {
      throw "Got an error " + error.code + " : " + error.message;
    }
  });
});