# Data Structures and Algorithms

A C# console app implementation of the exercises found in the Udemy course ["Master the Coding Interview: Data Structures + Algorithms"](https://www.udemy.com/course/master-the-coding-interview-data-structures-algorithms/), created by Andrei Neagoie

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

Lessons in the course are implemented as interchangeble classes. Each course section is represented as a separate namespace. Only the lessons that included any significant coding were included in this repo.

Class name formats are:
- For course lessons: *Lesson + lesson_number + lesson_name* (e.g. `Lesson26BigOAndScalability.cs`)
- For course lessons with multiple exercises: *Lesson + lesson_number + exercise_name* (e.g. `Lesson72TwoSum.cs`)

### Prerequisites

You will need the .NET Core version 3.1 (link to download [here](https://dotnet.microsoft.com/download)).
.NET Core 2.2 is also supported, just set the `<TargetFramework>` tag in *DataStructuresAndAlgorithms.csproj* to:

```wsdl
<TargetFramework>netcoreapp2.2</TargetFramework>
```

### Installing

Simply clone the repository to your local machine and run the project. It's really that simple!

To run a specific lesson example go to *Program.cs* and swap the lesson class to the desired one and run the application.

Example for running *Lesson 76. - Hash Collisions*:
```csharp
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

Please read [CONTRIBUTING.md](CONTRIBUTING.md) for details on our code of conduct, and the process for submitting pull requests to the project.

## Authors

* **Nenad Misic** - *Initial work* - [shonmisic](https://github.com/shonmisic)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* Big thanks to [aneagoie](https://github.com/aneagoie/) for creating the Udemy course!
* The course can be found [here](https://www.udemy.com/course/master-the-coding-interview-data-structures-algorithms/)
* Hat tip to [PurpleBooth](https://gist.github.com/PurpleBooth) for awesome [README.md](https://github.com/PurpleBooth/a-good-readme-template) and [CONTRIBUTING.md](https://github.com/PurpleBooth/a-good-readme-template/blob/main/CONTRIBUTING.md) templates


