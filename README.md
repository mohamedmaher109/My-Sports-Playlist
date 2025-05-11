# My-Sports-Playlist
Users love to follow their favorite sports matches and create personalized watchlists. We want you to design a simple web app where users can browse matches and add matches to a personal playlist to watch later.

Backend Setup Instructions:
Clone the repository:

git clone https://github.com/yourusername/my-sports-playlist-backend.git
Navigate to the project directory:


cd my-sports-playlist-backend
Set up and configure the database as per the backend documentation.

Install dependencies:


dotnet restore
Build and run the backend:


dotnet run
The API will be available at http://localhost:5000.

API Documentation:
Endpoints:
POST /auth/login: Logs in a user and returns a JWT token.

POST /auth/register: Registers a new user.

GET /matches: Retrieves a list of all available matches.

POST /playlist/add: Adds a match to the user's playlist.

DELETE /playlist/remove/{matchId}: Removes a match from the user's playlist.
