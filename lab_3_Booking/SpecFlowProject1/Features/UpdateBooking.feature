Feature: UpdateBooking

@tag1
Scenario: update the booking
	When I create update booking 
	Then verify booking is updated
