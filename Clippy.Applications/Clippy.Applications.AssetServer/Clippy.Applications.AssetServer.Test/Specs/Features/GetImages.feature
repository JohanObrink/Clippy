Feature: GetImages
	In order to avoid having to rescale my images
	As a web administrator
	I want to be able to auto scale and compress from uri

Scenario: Get original image from root
	Given There is an image called "image.png"
	When I visit "image.png"
	Then I should see "image.png"
