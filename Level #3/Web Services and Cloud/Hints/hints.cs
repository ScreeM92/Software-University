// Enable CORS - App_Start/Startup.Auth.cs
app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

// Set-up JSON response - App_Start/WebApiConfig.cs
config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

// Setup CamelCaseProperties - App_Start/WebApiConfig.cs
config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

// Set-up static class Create in DbContext
public static NewsContext Create()
{
	return new NewsContext();
}

// Add method for creating HttpResponse with text message and add it in BaseApiController:
protected ResponseMessageResult CreateResponse(HttpStatusCode statusCode, string message)
{
	return this.ResponseMessage(this.Request.CreateResponse(statusCode,
		new
		{
			Message = message
		}));
}

// Using Enum
if (model.Status != null)
{
	BugStatus newStatus;
	bool isSucessful = Enum.TryParse(model.Status, out newStatus);
	if (!isSucessful)
	{
		return this.BadRequest("Invalid bug status");
	}

	bug.Status = model.Status;
}

// *********************************************************************************
// Testing with Moq
// 1. Create MoqContainer
// 2. Change Controller to use userProfiver with dependency injection
// 3. Setup mockContext and MockUserProdiver
// *********************************************************************************

// *********************************************************************************
// Integration tests
// Change Tests project to use test database like NewsTestDb

// Use TestServer:
[TestInitialize]
public void TestInit()
{
	Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

	// Start OWIN testing HTTP server with Web API support
	this.httpTestServer = TestServer.Create(appBuilder =>
	{
		var config = new HttpConfiguration();
		WebApiConfig.Register(config);

		var startup = new Startup();
		startup.Configuration(appBuilder);

		appBuilder.UseWebApi(config);
	});
	this.httpClient = this.httpTestServer.HttpClient;

	//Clean Users and News tables from Db
	CleanDatabase();
}
		
// SetUp TestCleanup
[TestCleanup]
public void TestCleanup()
{
	this.httpTestServer.Dispose();
}

// Clean the test db before every test with:
private static void CleanDatabase()
{
	// Clean all data in all database tables
	using (var dbContext = new NewsContext())
	{
		dbContext.News.Delete();
		dbContext.Users.Delete();
		// .. add more tables if needed
		dbContext.SaveChanges();
	}
}

// Use private method for seeding during test initialize
// Use private methods for register and login if needed