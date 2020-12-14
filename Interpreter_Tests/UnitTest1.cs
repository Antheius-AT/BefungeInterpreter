using System;
using System.Collections.Generic;
using Interpreter;
using Interpreter.AdditionalComponents;
using Interpreter.Interfaces;
using Interpreter.InterpreterComponents;
using NUnit.Framework;

namespace Interpreter_Tests
{
    public class Tests
    {
        private BefungeInterpreter interpreter;
        private IInputHandler inputHandler;
        private IOutputHandler outputHandler;
        private Torus torus;
        private ExecutableCodeContainer codeContainer;
        private ICommandParser commandParser;
        private ProgramCounter pointer;
        private Stack<long> stack;

        [SetUp]
        public void Setup()
        {
            this.torus = new Torus();
            this.commandParser = new DefaultCommandParser(this.stack, this.pointer, new Random(), this.outputHandler, this.inputHandler, this.torus);
        }

        [Test]
        [TestCase(@"64+""!dlroW, olleH"">:#,_@")]
        [TestCase(@"Hallo      Duda
")]
        [TestCase(@"      060p070                                                           p'O80v
    pb2*90p4$4>                                                         $4$>v>
  v4$>4$>4$>4$>#                                                        ARGH>!
 <{[BEFUNGE_97]}>                                                       FUNGE!
 ##:-:##   #####*         4$*>4$      >060p>    60g80g -!#v_  60g1+     60p60v
 #vOOGAH               **>4$>^!!eg    nufeB^    $4$4$4 $4<v#<<v-*2a::   v7-1g<
 #>70g>90g-!          #@_^Befunge!!   123456    123456 VvVv!#!>Weird!   >0ggv*
  ^$4$4p07+1g07      ,a<$4<   <$4$4<  <$4$4<    <$4$4< <<#<*-=-=-=-=-*  -=-=v*
   ::48*-#v_>,4$>    4$4$4     $4$4$  4$4$4$    4$4$4$ 4$^*!*   XXXXXX   XXX> 
     BOINK>$60g1-7  0g+d2*     %'A+,1 $1$1$1    $1$1$1 $>^<$     HAR!!!  8888 
        Befunge_is  such_a     pretty langua    ge,_is n't_i     t?_It_  8888 
           looks_so much_l     ike_li ne_noi    se_and it's_     STILL_  ‘88’ 
Turing-     Complet e!_Cam     ouflag e_your    code!! Confu     se_the       
hell_out   of_every one_re     ading_ your_co  de._Oh, AND_y     ou.:-) ,o88o.
 Once_this_thing_i   s_code   d,_rea  ding_it_back_ver ges_on   the_imp 888888
  ossible._Obfusc     ate_the_obfus    cated!_Befunge_ debuggers_are__  888888
   your_friends!       By:_Alexios     Chouchou las... X-X-X-X-X-X-X!   888888
      -=*##*=-           \*****/         9797*  -=97=- !@-*=  *****     ‘""88P’
                                                       *!@-*
                                                       = *!@-
                                                       -= *!@                  
                                                       @-= *!")]
        public void Do_Coordinates_Match_After_CallTo_PrepareTorus(string code)
        {
            var interpreter = new BefungeInterpreter(this.torus, this.pointer, new ExecutableCodeContainer(code), this.commandParser);

            interpreter.PrepareTorus(code);

            string control = string.Empty;

            foreach (var item in this.torus.TorusContent)
            {
                control += item;
            }

            Assert.AreEqual(code, control.Replace(" ", string.Empty));
        }
    }
}