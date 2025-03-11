# NanoCart 🛒
An un-opinionated shopping cart RESTful microservice, powered by:
  - .NET Core
  - Dapper
  - SQLite

NanoCart Only Cares About Two Things: The Company and the Cart.

NanoCart doesn't store product data, or keep sessions, or require a login. It keeps a record of the cart, the company that it belongs to, a secret (that can be anything, as long as it's a string) 
that's used to provide a basic smoke test against the validity of the request, and a list of IDs. 

What are the IDs? NanoCart doesn't care. That's up to you to decide.


