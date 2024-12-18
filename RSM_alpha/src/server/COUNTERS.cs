using LogicAPI.Server.Components;
namespace rsm
{
    public class COUNTER32: LogicComponent
    {
        int finVal = 0;
        const int maxVal = 15;//4294967295;
        //32 - LOAD
        //33- UP/DOWN
        //34 - RESET
        //35 - CLOCK
        protected override void DoLogicUpdate()
        {

            int A = io.input(0,31,Inputs);
            //Only work on clock
            if(Inputs[35].On){
                //Count up or down?
                if(Inputs[33].On){
                    finVal--;
                }else{
                    finVal++;
                }
                //Fake overflow so that way we dont get some crazy number after a few hundred clock ticks
                if(finVal > maxVal){
                    finVal = 0;
                }
            }
            //If we are equal to the maxVal set the overflow output for ripple carry
            if(finVal == maxVal){
                Outputs[32].On = true;
            }else{
                Outputs[32].On = false;
            }
            //Load
            if(Inputs[32].On){
                finVal = A;
            }
            //Clear/Reset
            if(Inputs[34].On){
                finVal = 0;
            }
            io.output(0,31,finVal,Outputs);
        }
    }
    public class COUNTER16: LogicComponent
    {
        int finVal = 0;
        const int maxVal = 65535;
        //16 - LOAD
        //17- UP/DOWN
        //18 - RESET
        //19 - CLOCK
        protected override void DoLogicUpdate()
        {
            int A = io.input(0,15,Inputs);

            //Only work on clock
            if(Inputs[19].On){
                //Count up or down?
                if(Inputs[17].On){
                    finVal--;
                }else{
                    finVal++;
                }
                //Fake overflow so that way we dont get some crazy number after a few hundred clock ticks
                if(finVal > maxVal){
                    finVal = 0;
                }
            }
            //If we are equal to the maxVal set the overflow output for ripple carry
            if(finVal == maxVal){
                Outputs[16].On = true;
            }else{
                Outputs[16].On = false;
            }
            //Load
            if(Inputs[16].On){
                finVal = A;
            }
            //Clear/Reset
            if(Inputs[18].On){
                finVal = 0;
            }
            io.output(0,15,finVal,Outputs);
        }
    }
    public class COUNTER8: LogicComponent
    {
        int finVal = 0;
        const int maxVal = 255;
        //8 - LOAD
        //9- UP/DOWN
        //10 - RESET
        //11 - CLOCK
        protected override void DoLogicUpdate()
        {
            int A = io.input(0,7,Inputs);
            //Only work on clock
            if(Inputs[11].On){
                //Count up or down?
                if(Inputs[9].On){
                    finVal--;
                }else{
                    finVal++;
                }
                if(finVal > maxVal){
                    finVal = 0;
                }
            }
            //If we are equal to the maxVal set the overflow output for ripple carry
            if(finVal == maxVal){
                Outputs[8].On = true;
            }else{
                Outputs[8].On = false;
            }
            //Load
            if(Inputs[8].On){
                finVal = A;
            }
            //Clear/Reset
            if(Inputs[10].On){
                finVal = 0;
            }
            io.output(0,7,finVal,Outputs);
        }
    }
}