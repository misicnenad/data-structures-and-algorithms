# Data Structures and Algorithms

A C# implementation of the exercises found in the Udemy course ["Master the Coding Interview: Data Structures + Algorithms"](https://www.udemy.com/course/master-the-coding-interview-data-structures-algorithms/).

Created as a console app

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

Lessons are implemented as interchangeble classes. Each course section containing the lessons is represented as a separate namespace. Only the lessons that included any significant coding were included in this repo.

Class name formats are:
- For course lessons: *Lesson + lesson_number + lesson_name* (e.g. `Lesson26BigOAndScalability.cs`)
- For course lessons with multiple exercises: *Lesson + lesson_number + exercise_name* (e.g. `Lesson72TwoSum.cs`)

### Prerequisites

You will need the .NET Core version 3.1 (link to download [here](https://dotnet.microsoft.com/download)).
.NET Core 2.2 is also supported, set the `<TargetFramework>` tag in `DataStructuresAndAlgorithms.csproj` to:

```
<TargetFramework>netcoreapp2.2</TargetFramework>
```

### Installing

Simply clone the repository to your local machine and run the project. It's that simple!

To run a specific lesson example go to `Program.cs` file and swap the lesson class to the desired one and start the application.

Example to start *Lesson 76. - Hash Collisions*:
```
static void Main(string[] args)
{
    var lesson = new Lesson76HashCollisions();
    lesson.Run();
}
```

Console output:
```
54
abra kadabra
ahhhhhh!
```

## Contributing

Please read [CONTRIBUTING.md](CONTRIBUTING.md) for details on our code of conduct, and the process for submitting pull requests to us.

## Authors

* **Nenad Misic** - *Initial work* - [shonmisic](https://github.com/shonmisic)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* Big thanks to [Andrei Neagoie](https://github.com/aneagoie/) for creating the course!
* The course can be found ["here"](https://www.udemy.com/course/master-the-coding-interview-data-structures-algorithms/)


