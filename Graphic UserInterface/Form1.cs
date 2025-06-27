using System;
using System.Collections.Generic;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace CyberSecurityAwarenessBot
{
    public partial class Form1 : Form
    {
        // ============= STORAGE ================
        private List<TaskItem> tasks = new List<TaskItem>();
        private List<string> activityLog = new List<string>();
        private int quizScore = 0;
        private int quizIndex = -1;

        private List<(string question, string[] options, string answer, string explanation)> quizQuestions;

        public Form1()
        {
            InitializeComponent();
            InitializeQuiz();
            PlayWelcomeAudio();
            AppendChat("👋 CyberBot: Welcome to your Cybersecurity Assistant!\nType a question or click a menu item to get started.");
        }

        // ============= SEND BUTTON ================
        private void sendButton_Click(object sender, EventArgs e)
        {
            string userText = userInput.Text.Trim();
            if (string.IsNullOrWhiteSpace(userText)) return;

            AppendChat("You: " + userText);
            userInput.Clear();

            // NLP detection
            string lower = userText.ToLower();

            if (lower.Contains("add task"))
            {
                // simulate NLP
                string[] parts = userText.Split('-');
                if (parts.Length >= 2)
                {
                    string title = parts[1].Trim();
                    string description = $"Remember to do: {title}";
                    tasks.Add(new TaskItem { Title = title, Description = description });
                    AppendChat($"✅ Task added: {title}\n{description}\nWould you like a reminder? Type something like 'remind me in X days'.");
                    activityLog.Add($"Task added: {title}");
                }
                else
                {
                    AppendChat("🤖 Please use 'Add task - [task name]'.");
                }
                return;
            }

            if (lower.Contains("remind me in"))
            {
                int days = ExtractDays(userText);
                if (tasks.Count > 0)
                {
                    var lastTask = tasks[tasks.Count - 1];
                    lastTask.ReminderDays = days;
                    AppendChat($"🔔 Reminder set for '{lastTask.Title}' in {days} days.");
                    activityLog.Add($"Reminder set: {lastTask.Title} in {days} days");
                }
                

                else
                {
                    AppendChat("🤖 No active task to remind about.");
                }
                return;
            }

            if (lower.Contains("show activity log") || lower.Contains("what have you done"))
            {
                ShowActivityLog();
                return;
            }

            // quiz answer handler
            if (quizIndex >= 0)
            {
                ProcessQuizAnswer(userText);
                return;
            }

            // common keywords
            if (lower.Contains("thank"))
            {
                AppendChat("🙏 You’re welcome! Stay secure!");
                return;
            }

            // fallback
            AppendChat("🤖 Sorry, I didn’t understand that. Try typing 'add task - ...' or start the quiz.");
        }

        // ============= QUIZ LOGIC ================
        private void InitializeQuiz()
        {
            quizQuestions = new List<(string, string[], string, string)>
            {
                ("What is phishing?", new[] {"A) Fake emails", "B) Strong password", "C) VPN", "D) None"}, "A", "Phishing is a scam using fake emails."),
                ("What should you do if you get a suspicious email?", new[] {"A) Reply", "B) Ignore", "C) Report", "D) Click"}, "C", "Always report phishing emails."),
                ("Is reusing passwords safe?", new[] {"A) Yes", "B) No"}, "B", "Never reuse passwords."),
                ("VPN is used to?", new[] {"A) Clean PC", "B) Encrypt traffic", "C) Hack", "D) Block ads"}, "B", "VPN encrypts your data."),
                ("What is ransomware?", new[] {"A) Anti-virus", "B) File lock malware", "C) Password", "D) Firewall"}, "B", "It locks your files for money."),
                ("A strong password includes?", new[] {"A) 1234", "B) Name", "C) Complex characters", "D) birthday"}, "C", "Strong passwords use symbols."),
                ("What is social engineering?", new[] {"A) Tech hacking", "B) Social parties", "C) Tricking humans", "D) None"}, "C", "Social engineering tricks people."),
                ("HTTPS means?", new[] {"A) Encrypted", "B) Public", "C) Unsafe", "D) Spam"}, "A", "HTTPS is secure."),
                ("Antivirus does what?", new[] {"A) Makes PC slow", "B) Protects against malware"}, "B", "It helps against malware."),
                ("Two-factor authentication does what?", new[] {"A) Makes passwords weak", "B) Adds extra security"}, "B", "Adds an extra step of protection.")
            };
        }

        private void startQuizMenuItem_Click(object sender, EventArgs e)
        {
            quizIndex = 0;
            quizScore = 0;
            AskQuizQuestion();
            activityLog.Add("Quiz started");
        }

        private void AskQuizQuestion()
        {
            if (quizIndex < quizQuestions.Count)
            {
                var q = quizQuestions[quizIndex];
                AppendChat($"🧩 Quiz:\n{q.question}\n{string.Join("\n", q.options)}\n(Type the letter A, B, C, etc.)");
            }
            else
            {
                string result = quizScore >= 7 ? "🎉 Great job! You’re a cybersecurity pro!" : "📚 Keep learning!";
                AppendChat($"✅ Quiz complete! Your score: {quizScore}/{quizQuestions.Count}\n{result}");
                activityLog.Add($"Quiz completed: {quizScore} points");
                quizIndex = -1;
            }
        }

        private void ProcessQuizAnswer(string answer)
        {
            var q = quizQuestions[quizIndex];
            if (answer.Trim().Equals(q.answer, StringComparison.OrdinalIgnoreCase))
            {
                quizScore++;
                AppendChat($"✅ Correct! {q.explanation}");
            }
            else
            {
                AppendChat($"❌ Wrong! {q.explanation}");
            }
            quizIndex++;
            AskQuizQuestion();
        }

        // ============= TASK + REMINDER VIEWING ===============
        private void showTasksMenuItem_Click(object sender, EventArgs e)
        {
            if (tasks.Count == 0)
            {
                AppendChat("🗒️ No tasks found.");
            }
            else
            {
                var sb = new StringBuilder();
                foreach (var t in tasks)
                {
                    sb.AppendLine($"- {t.Title} ({t.Description}) Reminder: {t.ReminderDays} days");
                }
                AppendChat("🗒️ Your tasks:\n" + sb.ToString());
            }
        }

        private void showRemindersMenuItem_Click(object sender, EventArgs e)
        {
            var withReminders = tasks.FindAll(x => x.ReminderDays > 0);
            if (withReminders.Count == 0)
            {
                AppendChat("🔔 No active reminders.");
            }
            else
            {
                var sb = new StringBuilder();
                foreach (var t in withReminders)
                {
                    sb.AppendLine($"- {t.Title} in {t.ReminderDays} days");
                }
                AppendChat("🔔 Your reminders:\n" + sb.ToString());
            }
        }

        private void showActivityLogMenuItem_Click(object sender, EventArgs e)
        {
            ShowActivityLog();
        }

        private void ShowActivityLog()
        {
            int count = activityLog.Count;
            int start = count >= 5 ? count - 5 : 0;
            var last = activityLog.GetRange(start, count - start);
            AppendChat("📋 Activity log:\n" + string.Join("\n", last));
        }

        // ============= HELPERS ================
        private int ExtractDays(string input)
        {
            foreach (var word in input.Split())
            {
                if (int.TryParse(word, out int days))
                    return days;
            }
            return 0;
        }

        private void PlayWelcomeAudio()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("welcome_message.wav"); 
                player.Play();
            }
            catch
            {
                AppendChat("CyberBot: (voice unavailable)");
            }
        }

        private void AppendChat(string message)
        {
            chatBox.AppendText(message + "\n\n");
        }
    }

    public class TaskItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ReminderDays { get; set; } = 0;
    }
}



