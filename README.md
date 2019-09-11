# CQRS code example

This is an example of a CQRS architecture I've created.

# Business context

*Disclaimer*: the business context is an idea used solely for giving an example of the CQRS architecture. There is no intention for it to be commercialised.

### Actors

#### Tutor

A user who signs up to the application, with one or more qualifications to one or more languages. So that he/she can teach those languages online.
A tutor is also expected to maintain a calendar in which proposals can be made for certain time slots to give the lessons.

#### Student

A user who signs up to the application, wanting to learn one or more languages. A student can make a proposal to study a language with a weekly schedule.

### Workflow

- A student makes a proposal of a language he/she wants to learn and a schedule of when he/she wants to take the lessons
- A tutor is then assigned to this proposal
- The tutor is then able to choose to either accept or reject the proposal.
- If the tutor accepts the proposal, the lesson schedule will then be put onto the tutor's calendar (this is not done in code).
- If the tutor declines the proposal, the student will be notified. The student will need to make a new proposal.
