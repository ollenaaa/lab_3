Feature: ReadBooking

@tag1
Scenario: Read the bookings
	When I send read the booking request
	Then the response code should be OK
