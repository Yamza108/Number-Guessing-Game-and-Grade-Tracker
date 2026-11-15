# Assignment 02 – Number Guessing Game & Grade Tracker

## Setup
Requires .NET 8 SDK (10.0.302).
- Run game: `dotnet run --project GuessingGame`
- Run tracker: `dotnet run --project GradeTracker`
- Run tests: `dotnet test`

## Features
(Guessing game: 1–100, 7 tries, higher/lower hints, replay menu. Grade tracker: add students with scores, report with average/high/low/grade, repeating menu.)

## Design
Each app separates logic (`GameLogic`, `Grading`/`Student`) from console I/O (`Program.cs`). Logic classes never touch `Console`, so they are unit-testable. `Program.cs` is split into small methods (`RunMenu`, `PlayRound`, `AddStudent`, `ShowReport`, `ReadInt`).

## Grade scale
A ≥ 90, B ≥ 80, C ≥ 70, D ≥ 60, else F (based on average).

## Assumptions & limitations
- Scores are integers 0–100; max 20 scores per student.
- Data is in memory only; lost on exit.
- Student names are not required to be unique.
- Console input/output is not covered by automated tests (only the logic is).