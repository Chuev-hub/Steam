# Steam 🎮
## Description ✏️

Command project, a copy of the [Steam platform](https://store.steampowered.com/), desktop application.

There is registration and login, the ability to add friends, change information about yourself in your personal account.

On the main page you can see the games that you can view, add to cart or wishlist. Bought games are in the library, where you can see information about them (also you can do it on the page in the store).

For start using application, you should register or login to your personal account.

## Stack 📋
- C# WPF Application
- MVVM
- SQL Server
- 3tier
- EF6
- Steam Api

## Stack description 💻
The project was written using the WPF and has a 3tier architecture:

- DAL (Data access layer)
- BLL (Business logic layer)
- UI (User interface)

MVVM (Model View View-Model) software design pattern is used here.

Data at the first launch is collected from the API of the original Steam and fills the SQL Server database. EF6 was used to access the data.
