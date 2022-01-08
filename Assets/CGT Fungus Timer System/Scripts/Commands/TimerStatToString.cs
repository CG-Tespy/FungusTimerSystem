using UnityEngine;
using System.Collections.Generic;

namespace Fungus.TimeSys
{
	[CommandInfo("Timer", "Timer Stat to String", "Puts the value of a timer stat into a String Variable with the specified min digit count")]
	public class TimerStatToString : TimerCommand
	{
		[SerializeField]
		TimerStat stat;

		[Tooltip("The minimum amount of digits the output should have. Said output will be padded with 0s at the front as appropriate.")]
		[SerializeField]
		[Range(1, 99)]
		int minDigitCount = 2;

		[Tooltip("Where the converted string value will go.")]
		[SerializeField]
		[VariableProperty(typeof(StringVariable))]
		StringVariable output;

        public override void OnEnter()
        {
			bool nothingToOutputTo = output == null;

			if (nothingToOutputTo)
            {
				LetUserKnowThisCantDoItsThing();
				Continue();
				return;
            }

            base.OnEnter();
			
			UpdateStatDict();
			GenerateOutput();

			Continue();
        }

		protected virtual void LetUserKnowThisCantDoItsThing()
        {
			string messageFormat = "TimerStatsToString Command in Flowchart {0}, Block {1} has no output StringVariable to work with.";
			string message = string.Format(messageFormat, this.GetFlowchart().name, this.ParentBlock.BlockName);
			Debug.LogWarning(message);
        }

		protected virtual void UpdateStatDict()
        {
			// So we won't need to work with any ugly switch statements
			statDict[TimerStat.milliseconds] = timeRecorded.Milliseconds;
			statDict[TimerStat.seconds] = timeRecorded.Seconds;
			statDict[TimerStat.minutes] = timeRecorded.Minutes;
			statDict[TimerStat.hours] = timeRecorded.Hours;
			statDict[TimerStat.days] = timeRecorded.Days;
        }

		protected Dictionary<TimerStat, int> statDict = new Dictionary<TimerStat, int>();
		
		protected virtual void GenerateOutput()
        {
			int statValue = statDict[stat];
			string ensuresMinimumDigitCount = "D" + minDigitCount;
			string resultValue = statValue.ToString(ensuresMinimumDigitCount);
			output.Value = resultValue;
        }

        public override string GetSummary()
        {
			string timerName = timer.Key;
			string outputVarName = GetOutputVarName();
			string result = string.Format(summaryFormat, timerName, stat, minDigitCount, outputVarName);

			return result;
        }

		protected virtual string GetOutputVarName()
        {
			// Helper for GetSummary
			string result = "<noVarAssigned>";
			bool varIsThere = output != null;

			if (varIsThere)
			{
				string variableName = output.Key;
				result = variableName;
			}

			return result;
		}

		protected static string summaryFormat = "{0}, {1}, {2} digits, {3}";
    }
}