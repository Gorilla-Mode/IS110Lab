namespace Lab3;

/// <summary>
/// Class representing a student with grades in three subjects
/// </summary>
public class Student
{
    //Instansvariabler med properties for å gjøre dem lesbare, settere er private for å forhindre endring utenfor klassen
    public  string StudentId {get; private set;}
    public string Name {get; private set;}
    public decimal GradeIs110 {get; private set;}
    public decimal GradeIs105 {get; private set;}
    public decimal GradeBe112 {get; private set;}
    
    //Konstruktør som initialiserer instansvariablene
    public Student(string studentId, string name, decimal gradeIs110, decimal gradeIs105, decimal gradeBe112)
    {
        StudentId = studentId;
        Name = name;
        GradeIs110 = gradeIs110;
        GradeIs105 = gradeIs105;
        GradeBe112 = gradeBe112;
    }

    
    public decimal GetAggregate()
    {
        return (GradeIs110 + GradeIs105 + GradeBe112);
    }
    
    public decimal GetPercentage()
    {
        return (GradeIs110 + GradeIs105 + GradeBe112) / 60 * 100;
    }
}