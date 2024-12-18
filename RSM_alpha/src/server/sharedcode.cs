using LogicAPI.Server.Components;
using System.Collections.Generic;

namespace rsm
{
	public class io{
		public static int input(int start, int end, IReadOnlyList<IInputPeg> inputs){
			int A = 0; 
			for(int x = start; x<end+1; x++){
                A += inputs[x].On ? 1<<x-start : 0;
            }
            return A;
		}

		public static int input_al(int start, int end, IReadOnlyList<IInputPeg> inputs){
			int A = 0; 
			for(int x = start; x<end+1; x++){
                A += inputs[x].On ? 0<<x-start : 1;
            }
            return A;
		}

		public static void output(int start, int end, int value, IReadOnlyList<IOutputPeg> outputs){
			for (int i = start; i < end; i++)
            {
                int bit = value & (1 << i-start);
                outputs[i].On = bit > 0;
            }
		}

		public static void output_al(int start, int end, int value, IReadOnlyList<IOutputPeg> outputs){
			for (int i = start; i < end; i++)
            {
                int bit = value & (1 << i-start);
                outputs[i].On = !(bit > 0);
            }
		}
	}
}