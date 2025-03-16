Jan-Joost van Zon, 2015-02-03:

This project demonstrates putting multiple levels of return actions in post data.
Pretty soon the QuestionAndAnswer.Mvc will be changed to put multi-level return actions in the URL's instead.
This project is here to keep a demo of how the code looks if you put it in post data.

A return action is a piece of data that describes what view to go to when you close the current view.
It is analogus to return URL's: an URL parameter that encodes the URL to go to after you close the current view.

Return actions are part of the platform-independent navigation model you program in the form of Presenters.
That way even the platform-independent presentation code can define the return actions, independent of web or MVC.

The problem with putting the return action information in the post data is that HTTP GET actions cannot receive post data.
If you program the MVC controllers normally, 
you would have an HTTP GET for each CRUD action 
and an HTTP POST for posting back the data.
Going to other action will be an HTTP GET,
upon which you loose the return action information if you put in in the post data.
If you encode the return action info in the URL you can still pass around return action information in between GET actions.