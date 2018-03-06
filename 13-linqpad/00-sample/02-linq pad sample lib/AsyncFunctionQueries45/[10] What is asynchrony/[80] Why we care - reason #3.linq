<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.ComponentModel</Namespace>
</Query>

/* If all your asynchronous methods follow a consistent protocol (for instance, by returning
Tasks, as we'll demonstrate in the following section), we can write code that does cool things
with concurrent operations - without caring (or knowing) about the specifics of those operations!

For instance, we can write a method that runs several operations in parallel, coalesces the
results into an array - while displaying a progress bar and Cancel button to the user.

In other words, we can work at a higher layer of abstraction. We can treat units of
concurrency just like we treat other programming units such as classes.

*/