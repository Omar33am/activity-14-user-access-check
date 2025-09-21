using System;

static bool IsAdmin(uint userId) => userId > 65536;
static bool IsUsernameValid(string username) => !string.IsNullOrWhiteSpace(username) && username.Length >= 3;
static bool ContainsRequiredChar(string password) => password.Contains('$') || password.Contains('|') || password.Contains('@');
static bool IsPasswordValid(string password, bool isAdmin)
{
    if (string.IsNullOrEmpty(password)) return false;
    var minLen = isAdmin ? 20 : 16;
    return ContainsRequiredChar(password) && password.Length >= minLen;
}

static uint ReadUserId()
{
    while (true)
    {
        Console.Write("Enter user id (number): ");
        var input = Console.ReadLine();
        if (uint.TryParse(input, out var id)) return id;
        Console.WriteLine("Please enter a valid positive number.");
    }
}

Console.Write("Enter username: ");
var username = Console.ReadLine() ?? "";

Console.Write("Enter password: ");
var password = Console.ReadLine() ?? "";

var userId = ReadUserId();

var admin = IsAdmin(userId);
var usernameValid = IsUsernameValid(username);
var hasSpecial = ContainsRequiredChar(password);
var minLen = admin ? 20 : 16;
var lengthOk = password.Length >= minLen;
var passwordValid = hasSpecial && lengthOk;

if (usernameValid && passwordValid)
{
    Console.WriteLine(admin ? "Access granted. Welcome, admin." : "Access granted. Welcome.");
}
else
{
    Console.WriteLine("Access denied.");
    if (!usernameValid) Console.WriteLine("Username must have at least 3 characters.");
    if (!hasSpecial) Console.WriteLine("Password must contain at least one of $, |, @.");
    if (!lengthOk) Console.WriteLine($"Password must be at least {minLen} characters long.");
}
