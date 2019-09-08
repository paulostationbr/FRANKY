using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Microsoft.Speech.Recognition;
using System.Speech.Synthesis;

namespace FRANKY
{
    class program
    {
        private static SpeechRecognitionEngine engine = null;
        private static SpeechSynthesizer sp = null;
        static void main(string[] args)
        {
            // Franky System
            // Desenvolvido por Paulo Ricardo

            engine = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("pt-BR"));
            engine.SetInputToDefautAudioDevice();
            sp = new SpeechSynthesizer();

            // Conversas System
            string[] conversas = {"Ola", "Bom Dia", "Boa Tarde", "Boa Noite", "Tudo Bem"};
            Choices c_conversas = new Choices(conversas);

            GrammarBuilder gb_conversas = new GrammarBuilder();
            gb_conversas.Append(c_conversas);

            Grammar g_conversas = new Grammar(gb_conversas);
            g_conversas.Name = "conversas";

            // Comando System
            string[] comandoSistema = {"que horas são", "que dia é hoje"};
            Choices c_comandoSistema = new Choices(comandoSistema);
            GrammarBuilder gb_comandoSistema = new GrammarBuilder();
            gb_comandoSistema.Append(c_comandoSistema);

            Grammar g_comandoSistema = new Grammar(gb_comandoSistema);
            gb_comandoSistema.Name = "sistema";

            // Home System
            Console.Write("!!!!!!!!!!!!!!!!!!!!!!!");
            engine.LoadGrammar(g_comandoSistema);
            engine.LoadGrammar(g_conversas);
            Console.Write("!!!!!!!!!!!!!!!!!!!!!!!");
            engine.SpeechRecognitionEngine += Rec;
            Console.Write("Pode Falar, Estou Lhe Ouvindo!");

            sp.SelectVoiceByHints(VoiceGender.Male);
            Console.ReadKey();
        }
        // Sistema de Voz
        private static void rec(object s, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Confidence >= 0.4f)
            {
                string speech = e.Result.Text;
                Console.WriteLine("Você Disse: " + speech = "Confiança: " + e.Result.Confidence);
                switch(e.Result.Grammar.Name)
                {
                    case "Conversas":
                       break;
                    case "sistema":
                       break;
                    default:
                       break;     
                }
            }
            //Sistema De Erro
            else
            {
                Speak("Não Ouvir Sua Voz Claramente, Diga Novamente!");
            }
        }
        private static void Speak(string text)
        {
            sp.SpeakAsyncCancelAll();
            sp.SpeakAsync(text);
        }
    }
}
// Acesse meu instagram: @PauloStation
// Acesse meu github: Github.com/paulostationbr
// AMANOTEAM ©️ 2019: amanoteam.com