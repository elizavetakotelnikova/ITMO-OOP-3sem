Current repository consists of OOP-labs written in C# language (IS ITMO y26). Last, the fifth lab - the most interesting one, is about creating an ATM-service. To implement it, I used docker container & stored data through PostgresSQL DBMS. 

List of commands:
1. log in [user/admin] [accountId PIN/password] - log in (sign in)
2. top up [amount] - top up the bank account (which is currently viewed)
3. withdraw [amount] - (withdraw money from bank account (which is currently viewed)
4. show balance {accountid - available for admin only} - show account balance (admin can see balance of any account)
5. see history - show transactions history
6. create user {username} - create new user (you need to be an admin can do this))
7. create account [userId] [PIN] - create new account (you need to be an admin to do this)
8. disconnect - disconnect from the system, log out
