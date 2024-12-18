using LogicAPI.Server.Components;
using LogicLog;
namespace rsm
{
    public class MC14512B : LogicComponent
    {
        protected override void DoLogicUpdate()
        {
            bool INH = Inputs[8].On;
            bool DIS = Inputs[12].On;

            int abc = 0;

            abc += Inputs[9].On ? 1 : 0;
            abc += Inputs[10].On ? 2 : 0;
            abc += Inputs[11].On ? 4 : 0;

            if(DIS){
                Outputs[0].On = false;
            }else if(INH){
                Outputs[0].On = false;
            }else{
                Outputs[0].On = Inputs[abc].On;
            }
        }
    }
    
    public class MC14500B : LogicComponent
    {
        bool ien = false;
        bool oen = false;
        bool disInst = false;
        int I = 0;

        private void allFlagsOff(){
            Outputs[2].On = false;
            Outputs[3].On = false;
            Outputs[4].On = false;
            Outputs[5].On = false;
            Outputs[1].On = false;
            Outputs[0].On = false;
        }

        protected override void DoLogicUpdate()
        {
            Outputs[6].On = Inputs[6].On;

            int inst = 0;
            if(!disInst){
                inst += Inputs[5].On ? 1 : 0;
                inst += Inputs[4].On ? 2 : 0;
                inst += Inputs[3].On ? 4 : 0;
                inst += Inputs[2].On ? 8 : 0;
            }

            if(Inputs[0].On){
                allFlagsOff();
                I = 0;
                oen = false;
                ien = false;
                disInst = false;
                Outputs[7].On =false;
                Outputs[1].On = false;
                Outputs[0].On = false;
            }

            if(I > 1){
                disInst = false;
            }
            if(disInst){
                if(Inputs[6].On){
                    I++;
                }
            }

            if(!disInst && Inputs[6].On){
            switch(inst){
                case 0: //NOPO
                    allFlagsOff();
                    Outputs[3].On = true;
                    break;
                case 1: //LD
                    allFlagsOff();
                    if(ien){
                        Outputs[7].On = Inputs[1].On;   
                    }else{
                        Outputs[7].On = false;
                    }
                    break;
                case 2: //LDC
                    allFlagsOff();
                    if(ien){
                        Outputs[7].On = !Inputs[1].On;
                    }else{
                        Outputs[7].On = true;
                    }
                    
                    break;
                case 3: //AND
                    allFlagsOff();
                    if(ien){
                        Outputs[7].On = Outputs[7].On & Inputs[1].On;
                    }else{
                        Outputs[7].On = false;
                    }
                    break;
                case 4: //ANDC
                    allFlagsOff();
                    if(ien){
                        Outputs[7].On = Outputs[7].On & !Inputs[1].On;
                    }else{
                        Outputs[7].On = false;
                    }
                    break;
                case 5: //OR
                    allFlagsOff();
                    if(ien){
                        Outputs[7].On = Outputs[7].On | Inputs[1].On;
                    }else{
                        Outputs[7].On = false;
                    }
                    break;
                case 6: //ORC
                    allFlagsOff();
                    if(ien){
                        Outputs[7].On = Outputs[7].On | !Inputs[1].On;  
                    }else{
                        Outputs[7].On = true;
                    }
                    
                    break;
                case 7: //XNOR
                    allFlagsOff();
                    //Bootleg XNOR
                    if(ien){
                        if(Outputs[7].On == Inputs[1].On){
                        Outputs[7].On = true;
                        }else{
                            Outputs[7].On = false;
                        }
                    }else{
                        Outputs[7].On = !Outputs[7].On;
                    }
                    break;
                case 8: //STO
                    allFlagsOff();
                    if(oen){
                        Outputs[1].On = Outputs[7].On;
                    }else{
                        Outputs[1].On = false;
                    }
                    Outputs[0].On = true;

                    break;
                case 9: //STOC
                    allFlagsOff();
                    if(oen){
                        Outputs[1].On = !Outputs[7].On;
                    }else{
                        Outputs[1].On = false;
                    }
                    Outputs[0].On = true;
                    break;
                case 10: //IEN
                    allFlagsOff();
                    ien = Inputs[1].On;
                    break;
                case 11: //OEN
                    allFlagsOff();
                    oen = Inputs[1].On;
                    break;
                case 12: //jmp
                    allFlagsOff();
                    Outputs[5].On = true;
                    break;
                case 13: //rtn
                    allFlagsOff();
                    Outputs[4].On = true;
                    disInst = true;
                    break;
                case 14: //SKZ
                    allFlagsOff();
                    if(!Outputs[7].On){
                        disInst = true;
                    }
                    break;
                case 15: //NOPF
                    allFlagsOff();
                    Outputs[2].On = true;
                    break;
                default:
                    break;
            }
        }
    }
}
}