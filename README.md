# Healthy Bug

This is a collaboratively coed One-button-game where you need to help a bug eat good apples and dismiss bad ones.

## Summary

  - [Code Overview](#code-overview)
  - [Getting Started](#getting-started)
  - [Runing the tests](#running-the-tests)
  - [Deployment](#deployment)
  - [Built With](#built-with)
  - [Contributing](#contributing)
  - [Versioning](#versioning)
  - [Authors](#authors)
  - [License](#license)
  - [Acknowledgments](#acknowledgments)

## Code Overview
KieferController.cs controls the bugs mouth, it rotates the upper half of the head to look like a mouth being opened, if space is pressed

MunchController.cs controls the munching-process. If space is pressed, this script activates a collider thats part of the lower mouth-half
This collider is larger than it needs to be to make the game more playable. it is the trigger for apples to be eaten
MunchController also checks, if any apples that enter the foodCollider are good or bad, if they are good, this scripts adds points to the players score, if they are bad, it removes points
MunchController also has a part that enables the reloading of the scene via the press of a button and manages game-overs if the score is too low

AppleLauncher.cs simply launches the apples at a point out of view. It uses two coroutines to launch good and bad apples at random intervals.
Good apples are launched more frequently than bad ones. This is balanced out by bad apples subtracting more points from the score than good ones add

AppleController.cs makes the apples move. Once they are instatiated by AppleLauncher.cs, the recieve a small push in the direction of an invisible goal that is positioned to the left and out of bounds. If the space key is pressed, they are pushed towards the bug, if it isn´t, they are pushed towards the left (towards the invisible goal)
If they leave the field of view, they are destroyed
If the enter the foodCollider while it is ective, they are also destroyed

GoodApple.cs has been deleted, its contents are used in some new existing scripts

## Getting Started

These instructions will get you a copy of the project up and running on
your local machine for development and testing purposes. See deployment
for notes on how to deploy the project on a live system.

### Prerequisites

What things you need to install the software and how to install them

    Give examples

### Installing

A step by step series of examples that tell you how to get a development
env running

Say what the step will be

    Give the example

And repeat

    until finished

End with an example of getting some data out of the system or using it
for a little demo

## Running the tests

Explain how to run the automated tests for this system

### Break down into end to end tests

Explain what these tests test and why

    Give an example

### And coding style tests

Explain what these tests test and why

    Give an example

## Deployment

Add additional notes about how to deploy this on a live system

## Built With

  - [Contributor Covenant](https://www.contributor-covenant.org/) - Used
    for the Code of Conduct
  - [Creative Commons](https://creativecommons.org/) - Used to choose
    the license

## Contributing

Please read [CONTRIBUTING.md](CONTRIBUTING.md) for details on our code
of conduct, and the process for submitting pull requests to us.

## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions
available, see the [tags on this
repository](https://github.com/PurpleBooth/a-good-readme-template/tags).

## Authors

  - **Billie Thompson** - *Provided README Template* -
    [PurpleBooth](https://github.com/PurpleBooth)
  - **Nelly Granson** - *Idea and Concept* -
    [NellyGranson](https://github.com/NellyGranson)
  - **Frederik Schneider** - *Started the project and coded baseline game* -
    [Zeltoss](https://github.com/Zeltoss)

See also the list of
[contributors](https://github.com/PurpleBooth/a-good-readme-template/contributors)
who participated in this project.

## License

This project is licensed under the [CC0 1.0 Universal](LICENSE.md)
Creative Commons License - see the [LICENSE.md](LICENSE.md) file for
details

## Acknowledgments

  - Hat tip to anyone whose code was used
  - Inspiration
  - etc
