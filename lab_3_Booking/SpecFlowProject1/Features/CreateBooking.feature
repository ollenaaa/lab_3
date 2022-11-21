Feature: CreateBooking

@tag1
Scenario: create the booking
	Given I send create booking request
	Then booking is created
