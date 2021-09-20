
  ## 4. Comparison Constraints
Equal Constraint Example
```csharp
Assert.That(result, Is.EqualTo(5));
```
Not Equal Constraint Example
```csharp
Assert.That(result, Is.Not.EqualTo(7));
csharp
Greater Than Constraint Example
```csharp
Assert.That(result, Is.GreaterThan(2));
Assert.That(result, Is.GreaterThanOrEqualTo(5));
```
Less Than Constraint Example
```csharp
Assert.That(result, Is.LessThan(9));
Assert.That(result, Is.LessThanOrEqualTo(5));
```
Ranges Example
```csharp
Assert.That(result, Is.InRange(5, 10));
```

## 5. String Constraints
String Equal / Not Equal Constraint Example
```csharp
Assert.That(result, Is.EqualTo("abcdefg"));
Assert.That(result, Is.Not.EqualTo("mnop"));
```
String Equal Ignore Case Example
```csharp
Assert.That(result, Is.EqualTo("ABCDEFG").IgnoreCase);
```
Substring Constraint Example
```csharp
Assert.That(result, Does.Contain("def").IgnoreCase);
Assert.That(result, Does.Not.Contain("igk").IgnoreCase);
```
Empty Example
```csharp
Assert.That(result, Is.Empty);
Assert.That(result, Is.Not.Empty);
```
Starts With / Ends With Examples
```csharp
Assert.That(result, Does.StartWith("abc"));
Assert.That(result, Does.Not.StartWith("efg"));

Assert.That(result, Does.EndWith("efg"));
Assert.That(result, Does.Not.EndWith("mno"));
```
Regex Constraint Example
```csharp
string result = "abcdefg";  

Assert.That(result, Does.Match("a*g"));
Assert.That(result, Does.Not.Match("m*n"));
```

## 6. Collection Constraints
All Items Examples
```csharp
int[] array = new int[] { 1, 2, 3, 4, 5 };
```
Not Null Example
```csharp
Assert.That(array, Is.All.Not.Null);
```
All Greater Than Example
```csharp
Assert.That(array, Is.All.GreaterThan(0));
```
All Less Than Example
```csharp
Assert.That(array, Is.All.LessThan(10));
```
Instance Of Example
```csharp
Assert.That(array, Is.All.InstanceOf<Int32>());
```
No Items Example
```csharp
Assert.That(array, Is.Empty);
Assert.That(array, Is.Not.Empty);
```
Exactly n Items Example
```csharp
Assert.That(array, Has.Exactly(5).Items);
```
Unique Items Example
```csharp
Assert.That(array, Is.Unique);
```
Contains Item
```csharp
Assert.That(array, Contains.Item(4));
```

## 7.Ordered Examples
Ascending
```csharp
Assert.That(array, Is.Ordered.Ascending);
```
Descending
```csharp
Assert.That(array, Is.Ordered.Descending);
```
By Single Property
```csharp
List<Employee> employees = new List<Employee>();
employees.Add(new Employee { Age = 32 });
employees.Add(new Employee { Age = 49 });
employees.Add(new Employee { Age = 57 });

Assert.That(employees, Is.Ordered.Ascending.By("Age"));
Assert.That(employees, Is.Ordered.Descending.By("Age"));
```
By Multiple Properties
```csharp
Assert.That(employees, Is.Ordered.Ascending.By("Age").Then.Descending.By("Name"));
```
SuperSet / SubSet Examples
```csharp
int[] array = new int[] { 1, 2, 3, 4, 5 };
int[] array2 = { 3, 4 };
Assert.That(array2, Is.SubsetOf(array));
```

## 8.Conditional Constraints
Null Constraint Examples
```csharp
Assert.That(array, Is.Null);
Assert.That(array, Is.Not.Null);
```
Boolean (True / False)
```csharp
bool result = array.Length > 0;
Assert.That(result, Is.True);
Assert.That(result, Is.False);
```
Empty Constraint Example
```csharp
Assert.That(array, Is.Empty);
```
Compound Constraints
AND constraint example
```csharp
Assert.That(result, Is.GreaterThan(4).And.LessThan(10));
```
OR example
```csharp
Assert.That(result, Is.LessThan(1).Or.GreaterThan(4));
```
NOT example
```csharp
Assert.That(result, Is.Not.EqualTo(7));
```
## 9.Directory / File Constraints
File or Directory exists.
```csharp
Assert.That(new FileInfo(path), Does.Exist);
Assert.That(new FileInfo(path), Does.Not.Exist);

Assert.That(new DirectoryInfo(path), Does.Exist);
Assert.That(new DirectoryInfo(path), Does.Not.Exist);
```
Same Path Example
```csharp
Assert.That(path, Is.SamePath(@"c:\documents\imp1").IgnoreCase);
```
Empty Directory. Is.Empty returns true when directory has no files.
```csharp
Assert.That(new DirectoryInfo(path), Is.Empty);
```

## 10.Type / Reference Constraints
Instance of example
```csharp
IEmployee emp = new Employee();

Assert.That(emp, Is.InstanceOf<IEmployee>());
Assert.That(emp, Is.Not.InstanceOf<string>());
```
Exact Same Type Constraint
```csharp
Assert.That(emp, Is.TypeOf<Employee>());
```
Assignable to another Type. For e.g. interface to implemented class.
```csharp
Assert.That(emp, Is.AssignableTo<Employee>());
```
## 11.Exceptions Constraints
Is Exception Throws By Method
```csharp
IEmployee emp = new Employee();
emp.Age = 0;
Assert.That(emp.IsSeniorCitizen(), Throws.Exception);
```
Expected / Same Type Exception
```csharp
Assert.That(emp.IsSeniorCitizen(), Throws.TypeOf<ArgumentException>());
```
Exception Message Comparison
```csharp
Exception ex = Assert.Throws<ArgumentException>(() => emp.IsSeniorCitizen());
Assert.That(ex.Message, Is.EqualTo("Age can not 0."));
```
