NotificationHub
=================

A way to quickly add a notification icon to a UIView

![increment](http://i.imgur.com/zpgkNtE.gif)

	Notifier hub = new Notifier(EarthImageView); // sets the count to 0
	hub.Increment(); // increments the count to 1, making the notification visible

###USAGE

	hub.Increment(); // increment by 1 
	hub.Increment(2); // increment by amount passed
	hub.Increment(NotificationAnimationType.Bump); // increment by 1 and animate change
	hub.Increment(2, NotificationAnimationType.Bump); // increment by amount passed and animate change
		
	hub.Decrement(); // decrement by 1 
	hub.Decrement(2); // decrement by amount passed
	hub.Decrement(NotificationAnimationType.Bump); // decrement by 1 and animate change
	hub.Decrement(2, NotificationAnimationType.Bump); // decrement by amount passed and animate change
	
	hub.Animate(NotificationAnimationType.Bump); // animate
	
    hub.MoveCircle(-15, 15); // move the notification circle
    hub.SetCircleColor(UIColor.Green, UIColor.White); // change the color of the circle color and text
    hub.ShowCount(); // show the count
    hub.HideCount(); // hide the count
	

Thanks to Richard Kim for the original RKNotificationHub https://github.com/cwRichardKim/RKNotificationHub