# User Access Check

This app checks if a username, password, and user ID meet the required conditions for access.

## Requirements:
- Username must be at least 3 characters long.
- Password must contain one of these special characters: `$`, `|`, or `@`.
- Admins (user ID > 65536) need a password with at least 20 characters.
- Non-admins need a password with at least 16 characters.

