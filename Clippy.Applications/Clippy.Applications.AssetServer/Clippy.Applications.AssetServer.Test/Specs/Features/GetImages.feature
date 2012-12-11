Feature: GetImages
	In order to avoid having to rescale my images
	As a web administrator
	I want to be able to auto scale and compress from uri

Scenario: Get original image from root
	Given There is an image called "/image.png"
	When I visit "/image.png"
	Then I should see the image

Scenario: Get original image from sub folder
	Given There is an image called "/foo/bar/image.png"
	When I visit "/foo/bar/image.png"
	Then I should see the image

Scenario: Get a rescaled image from root
	Given There is an image called "/image.png"
	When I visit "/125x182/image.png"
	Then I should see the image rescaled to 125x182
