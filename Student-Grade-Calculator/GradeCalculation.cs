// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;
public class GradeCalculation{
    public static void Main(string[] args){
        Console.WriteLine(IsPalindrome("Enter#*^&@student name!"));
        Console.WriteLine(IsPalindrome("madam"));
        Console.WriteLine(IsPalindrome("nurses run"));
        Console.WriteLine(IsPalindrome("nurses run!"));

        Dictionary<string, int> word_count = WordCount("This is a test. That is not a test.        Test");
        foreach (KeyValuePair<string, int> word in word_count){
            Console.WriteLine($"{word.Key}: {word.Value}");
        }
        
        // defining vriable for student name and number of courses 
        string student_name;
        int number_of_courses;

        // accepting student name and number of courses
        Console.WriteLine("Enter student name: ");
        student_name = Console.ReadLine();
        Console.WriteLine("Enter number of courses: ");
        number_of_courses = int.Parse(Console.ReadLine());

        // dictionay to store subjects and grades as key value pairs
        Dictionary<string, double> subjects = new Dictionary<string, double>();

        // loop through the number of courses and ask for subject name and grade
        for (int i = 0; i < number_of_courses; i++){
            Console.WriteLine($"Enter name of subject {i + 1}: ");
            string subject_name = Console.ReadLine();
            Console.WriteLine($"Enter grade of subject {i + 1}: ");
            double subject_grade = double.Parse(Console.ReadLine());

            // check for validity of grade, which must be between 0 and 100
            if (subject_grade < 0 || subject_grade > 100){
                Console.WriteLine("Invalid grade. Grade must be between 0 and 100");
                i--;
                continue;
            }

            // check for validity of subject name, which must not be empty
            if (subject_name == ""){
                Console.WriteLine("Subject name cannot be empty");
                i--;
                continue;
            }

            // check if subject already exists
            if (subject_name is not null && subjects.ContainsKey(subject_name)){
                Console.WriteLine("Subject already exists. Please enter a different subject");
                i--;
                continue;
            }

            subjects.Add(subject_name, subject_grade);
        }

        double gpa = CalculateGPA(subjects);

        Console.WriteLine($"GPA of {student_name} is {gpa}");
    }

    public static double CalculateGPA(Dictionary<string, double> subjects){
        double gpa = 0;
        foreach (KeyValuePair<string, double> subject in subjects){
            gpa += subject.Value;
        }
        return gpa / subjects.Count;
    }

    public static bool IsPalindrome(string sentence){
        // remove spaces, special chars and convert to lowercase
        sentence = Regex.Replace(sentence, @"[^a-zA-Z0-9]", "").ToLower();

        Console.WriteLine(sentence);    

        if (sentence == ""){
            return false;
        }

        // reverse the string
        char[] char_array = sentence.ToCharArray();
        Array.Reverse(char_array);
        string reversed_sentence = new string(char_array);

        // compare the reversed string with the original string
        if (sentence == reversed_sentence){
            return true;
        }
        return false;
    }


    public static Dictionary<string, int> WordCount(string sentence){
        Dictionary<string, int> word_count = new Dictionary<string, int>();

        // remove special chars and convert to lowercase
        sentence = Regex.Replace(sentence, @"[^a-zA-Z0-9 ]", "").ToLower();
        
        // remove extra spaces
        sentence = Regex.Replace(sentence, @"[\s]+", " ").ToLower();

        Console.WriteLine(sentence);
        // split the sentence into words
        string[] words = sentence.Split(" ");
        Console.WriteLine(words);

        foreach (String word in words){
            // check if word already exists in the dictionary
            if (word_count.ContainsKey(word)){
                word_count[word] += 1;
            }
            else{
                word_count.Add(word, 1);
            }
        }
        return word_count;
    }

}
