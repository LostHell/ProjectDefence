# ProjectDefence (SoftUni) - Fitness2You
Fitness2You project defence - SoftUni (E.Karadzhov - losthell)

1. Added database Models - ApplicationRole, ApplicationUser, Benefit, Class, Subscription, UserClass, UserSubscription
2. Added Models into DbContext
3. Added _Layout, Index Page, style/css and Image
4. Added Login page, Register page
5. Added User and Subscriptions Controller, refactored View Login,added new view Subscriptions
6. Added Service --IUsersService and UsersService with (UserManager, SignInManager)
7. Added ViewModels/Users only Login and Register
8. Added Change Password page
9. Added SeedData/ApplicationDbContextSeeder with username = Administrator, password = administrator, role = admin
10. Added Autoseeder for User
11. Added New database Table (Contact, Trainer)
12. Added Services folders with files - ClassService, FooterService, SubscriptionService
13. Added ViewModels folders with files - Account, Class, Footer, Subscription, User
14. Added Controller - Account, Classes, Subscriptions, Trainers
15. Added Views Account, Classes, Subscriptions, Trainers
16. Added AdminPanel with CRUD, IAdminServices with CRUD logic
17. Change button rout on Index Page

Att! Must implementing code in IFooterServices/FooterServices for Class and Contact