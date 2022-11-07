# EnglishTeacher.Api
REST API for English vocabulary learning application written in .Net

# General info
In this application, users can save words, they want to learn in English. They can also add their own sentences that contain these words (an example of word usage) to help remember it.
Learning mode allows users to try themselves. The application selects a packet of words in Polish, from a set that the user has created, which he must now try to translate. All the user's results - if translate was correct or not - are saved, so that better matching words can be chosen in future.
App can also find for user examples of sentences containing a word he wants to learn, using an external Free Dictionary API.

# Technologies
* .NET 6.0
* ASP.NET Web API, SqlServer, IdentityServer4
* CQRS
* LINQ
* Dependency Injection
