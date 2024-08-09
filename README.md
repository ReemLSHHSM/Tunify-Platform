# Tunify-Platform

## Overview

Tunify Platform is a music management application designed to help users organize their music libraries, create and manage playlists, and enjoy a rich experience with their favorite songs, albums, and artists. The application supports various features including user management, subscription plans, and playlist management.

## Entity Relationship Diagram (ERD)

![Tunify ERD Diagram](https://github.com/ReemLSHHSM/Tunify-Platform/blob/master/Tunify-Platform/Images/Tunify.png?raw=true)

## Entity Relationships

### `Users`
- **Primary Key (PK):** `Id` 
- **Relationships:**
  - **Subscription**: Each user has a subscription type. (`Subscription_ID` is a foreign key referencing the `Subscriptions` table)
  - **Playlists**: Users can create multiple playlists. (`User_ID` is a foreign key in the `Playlist` table)

### `Subscriptions`
- **Primary Key (PK):** `Id`
- **Relationships:**
  - **Users**: A subscription type can be associated with multiple users. (`Subscription_ID` is a foreign key in the `Users` table)

### `Artists`
- **Primary Key (PK):** `ID`
- **Relationships:**
  - **Songs**: Artists can have multiple songs. (`Artist_ID` is a foreign key in the `Songs` table)
  - **Albums**: Artists can release multiple albums. (`Artist_ID` is a foreign key in the `Albums` table)

### `Albums`
- **Primary Key (PK):** `ID`
- **Relationships:**
  - **Songs**: An album can contain multiple songs. (`Album_ID` is a foreign key in the `Songs` table)
  - **Artist**: Each album is released by an artist. (`Artist_ID` is a foreign key in the `Albums` table)

### `Songs`
- **Primary Key (PK):** `Id`
- **Relationships:**
  - **Artists**: Each song is performed by an artist. (`Artist_ID` is a foreign key in the `Songs` table)
  - **Albums**: Each song is part of an album. (`Album_ID` is a foreign key in the `Songs` table)
  - **Playlists**: Songs can be added to multiple playlists. (via `PlaylistSongs`)

### `Playlist`
- **Primary Key (PK):** `Id`
- **Relationships:**
  - **Users**: Each playlist is created by a user. (`User_ID` is a foreign key in the `Playlist` table)
  - **Songs**: Playlists can contain multiple songs. (via `PlaylistSongs`)

### `PlaylistSongs`
- **Primary Key (PK):** `Id`
- **Relationships:**
  - **Playlists**: Links songs to a playlist. (`Playlist_ID` is a foreign key referencing the `Playlist` table)
  - **Songs**: Links a song to a playlist. (`Song_ID` is a foreign key referencing the `Songs` table)

## Repository Pattern

### Overview

The Repository Design Pattern is a structural pattern that separates the logic that retrieves data from the underlying storage system from the rest of the application. This pattern helps in achieving a cleaner, more modular codebase by abstracting data access logic into separate classes called repositories.

### Benefits of the Repository Pattern

1. **Separation of Concerns**: By encapsulating the data access logic in repositories, you keep your controllers and other parts of the application decoupled from the details of data storage and retrieval.
   
2. **Testability**: Repositories provide a clear and consistent interface for data access, making it easier to mock or stub them during unit testing.

3. **Maintainability**: Changes to the data access logic, such as switching from one database to another or changing the queries, are confined to the repository layer, reducing the impact on the rest of the application.

4. **Reusability**: Common data access logic can be reused across different parts of the application by leveraging repositories.

### Implementation

In the Tunify Platform application, the Repository Design Pattern has been implemented as follows:

1. **Repository Interfaces**: Located in the `Repositories/Interfaces` folder, these interfaces define the methods for CRUD operations and other entity-specific logic for `Users`, `Playlist`, `Song`, and `Artist`.

2. **Repository Services**: Located in the `Repositories/Services` folder, these classes implement the repository interfaces, encapsulating the data access logic for each entity.

3. **Refactored Controllers**: Controllers now use repository instances to interact with the data layer. This change promotes separation of concerns and improves testability. Constructor injection is used to provide repositories to the controllers.

4. **Service Registration**: Repositories and controllers are registered in the `ConfigureServices` method of `Program.cs`, ensuring proper dependency injection and lifetime management.

