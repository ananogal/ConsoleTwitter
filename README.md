# Console Twitter
A twitter for the console

# Objective
Implement a console-based social networking application (similar to Twitter) satisfying the scenarios below.

# Features

#### Posting: Alice can publish messages to a personal timeline

```
> Alice -> I love the weather today
> Bob -> Damn! We lost!
> Bob -> Good game though.
```
#### Reading: I can view Alice and Bob’s timelines
```
> Alice
I love the weather today (5 minutes ago)

> Bob
Good game though. (1 minute ago)
Damn! We lost! (2 minutes ago)
```
#### Following: Charlie can subscribe to Alice’s and Bob’s timelines, and view an aggregated list of all subscriptions

```
> Charlie -> I'm in New York today! Anyone want to have a coffee?
> Charlie follows Alice
> Charlie wall
Charlie - I'm in New York today! Anyone want to have a coffee? (2 seconds ago)
Alice - I love the weather today (5 minutes ago)
> Charlie follows Bob
> Charlie wall
Charlie - I'm in New York today! Anyone wants to have a coffee? (15 seconds ago)
Bob - Good game though. (1 minute ago)
Bob - Damn! We lost! (2 minutes ago)
Alice - I love the weather today (5 minutes ago)
```

# How to Run

#### Clone this repository

git clone [https://github.com/ananogal/ConsoleTwitter.git] (https://github.com/ananogal/ConsoleTwitter.git)

and then navigate to clone directory.

#### On Windows

```
msbuild ConsoleTwitter.sln
```

#### On Mac and Linux
(You must have [Mono](http://www.mono-project.com/download/) installed)
```
xbuild ConsoleTwitter.sln
```

### To run the application
Please navigate to ./ConsoleTwitter/bin/Debug and:

#### On Windows
execute ``` consoleTwitter.exe ```

#### On Mac and Linux
execute ``` mono ./consoleTwitter.exe ```
