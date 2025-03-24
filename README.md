# NanoCart 🛒

**=== Still a work in progress ===** 

An un-opinionated shopping cart RESTful microservice, powered by:
  - .NET Core
  - Dapper
  - SQLite

NanoCart only cares about one thing: the cart.

NanoCart doesn't store product data, or keep sessions, or require a login. It keeps a record of the cart and a list of IDs attached to that cart. All carts are accessed through simple
endpoints and have an expiration date, creation date, last modified date, and last accessed date. 

Items can be added and removed. The cart expiry date can be refreshed. The entire cart can be deleted. Just don't ask it what product ID #5 is,
because it won't know. 


