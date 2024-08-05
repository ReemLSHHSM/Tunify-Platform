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
  

