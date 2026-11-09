# YouTube walkthrough outline (unlisted, ~8-10 min)

The brief requires you to record this yourself in your own voice (no AI voiceover). Suggested flow:

1. **Intro (30s)** — RaceDay, Part 2, what the API does.
2. **Run the API (1 min)** — start it, open Swagger UI, show every endpoint listed with descriptions.
3. **Code structure (2 min)** — Controllers, Models, DbContext (mirrors ERD), Dtos, TokenService, Program.cs.
4. **Authentication (2 min)** — register an Organiser and a Participant in Swagger, log in, paste the token into
   *Authorize*, show `GET /api/users/me`. Explain JWT carries id + role and passwords are hashed (show `Users` table).
5. **Role-based access (1.5 min)** — as Participant try `POST /api/events` (403); as Organiser succeed.
6. **Endpoints demo (2 min)** — create event -> add category -> enrol as Participant -> capture result -> view leaderboard.
7. **Unit tests (1.5 min)** — show test classes, run `dotnet test` (all green), point out success + failure cases.
8. **CI/CD (30s)** — GitHub Actions run, green build.

---

# Part 3 walkthrough outline (unlisted, ~10-12 min)

Record this yourself, in your own voice.

1. **Intro (30s)** — RaceDay Part 3: an MVC front end on top of the Part 2 API, plus Azure Blob Storage and Docker.
2. **MVC structure (2 min)** — Controllers / Views / Models (Api vs ViewModels) / Services. Open `RaceDayApiClient` and show there's no
   DbContext or EF reference in the MVC project: every read and write is an HTTP call. Show that validation errors come from the API.
3. **Session auth (1.5 min)** — Program.cs (`AddSession`), `UserSession` (JWT + role in the session), `RequireLoginAttribute`.
   Demo: open `/Organiser/Dashboard` while logged out → redirected to log in. Log in as a participant and try an organiser page → Access denied.
4. **Participant journey (2 min)** — register, filter events on the home page, open an event, enrol (race number shown),
   My Enrolments (green/red status badges), Profile → upload a picture.
5. **Organiser journey (2.5 min)** — dashboard totals, create an event with a banner, add categories, view enrolments,
   capture results (Finished / DNF), then switch to the participant's My Results ("1st out of N finishers").
6. **Blob Storage (1.5 min)** — `AzureBlobStorageService` and the upload endpoints in the API. Show the `raceday-images` container
   in the Azure Portal with the `event-banners/` and `profile-pictures/` folders, and the image URL on the event page.
7. **Docker (1.5 min)** — walk through the multi-stage Dockerfile, then run `docker build` and the single `docker run` command.
   Use the app at http://localhost:8080 to show it behaves the same as when run locally.
8. **CI (30s)** — the GitHub Actions run: solution build, MVC build, tests and Docker image build all green.
