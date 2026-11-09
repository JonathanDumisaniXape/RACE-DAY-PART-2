# Suggested commit sequence (20+ meaningful commits)

The brief requires at least 20 meaningful commits from **your own** GitHub account. Build the repo up in stages so the
history reflects real progress. Use a `part2-api` branch (or a `Part2` subfolder) as instructed. Suggested order:

1.  Add solution and empty Web API project (`RaceDay.sln`, `RaceDay.Api.csproj`)
2.  Add .gitignore
3.  Add EF Core entities matching the Part 1 ERD
4.  Add RaceDayDbContext with keys, constraints and relationships
5.  Add appsettings connection string and JWT settings
6.  Add DbSeeder with Part 1 reference data
7.  Add DTOs and validation rules
8.  Add TokenService and JWT authentication setup in Program.cs
9.  Add AuthController (register + login with hashed passwords)
10. Add UsersController (profile endpoints)
11. Add VenuesController
12. Add EventsController (browse + Organiser CRUD)
13. Add CategoriesController
14. Add EnrolmentsController
15. Add ResultsController
16. Add Swagger with JWT support and XML documentation
17. Generate the InitialCreate EF Core migration
18. Add test project and WebApplicationFactory setup
19. Add authentication tests
20. Add event management tests
21. Add role-based access tests
22. Add enrolment tests
23. Add result tests
24. Add GitHub Actions CI workflow
25. Add README (setup, roles, CI screenshot, video link)

Tip: `git add <specific files>` per step and commit with a clear message, rather than one big commit at the end.

---

# Part 3 — suggested commit sequence (20+ meaningful commits)

Work on a clearly named branch, e.g. `git checkout -b part3-mvc`. Commit each step from **your own** account.

1.  Fix EnrolmentsController routing (missing `[ApiController]` / `[Route("api")]`)
2.  Add `BannerImageUrl` and `ProfilePictureUrl` to the entities and DbContext
3.  Add the `AddImageUrls` EF Core migration
4.  Add `Azure.Storage.Blobs`, `IFileStorageService` and `AzureBlobStorageService`
5.  Add image upload rules and the event banner upload/delete endpoints
6.  Add the profile picture upload endpoint
7.  Add event filters and the `GET /api/events/mine` endpoint for the organiser dashboard
8.  Add total finishers, event date and distance to `ResultDto`
9.  Add `FakeFileStorage` and the Part 3 API tests
10. Scaffold the `RaceDay.Web` MVC project and add it to the solution
11. Add the API contract models and the typed `RaceDayApiClient`
12. Add `UserSession` (session-based auth state) and the session configuration in Program.cs
13. Add the `RequireLogin` role filter and the `ApiExceptionFilter`
14. Add the RaceDay theme (site.css), self-hosted Bootstrap 5.3, icons and fonts
15. Add the shared layout with role-specific navigation, flash messages and error pages
16. Add Login, Register, Logout and Access Denied
17. Add the participant home page with event filters and event cards
18. Add the event detail page with enrolment and leaderboard
19. Add My Enrolments (with cancel) and My Results
20. Add the Profile page with picture upload
21. Add the Organiser dashboard
22. Add the create/edit event form with banner upload
23. Add category management
24. Add the enrolments page for organisers
25. Add results capture and publishing
26. Add the Dockerfile and .dockerignore
27. Update the GitHub Actions workflow to build the MVC project and the Docker image
28. Update the README with setup, Azure and Docker run instructions
