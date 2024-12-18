using LogicAPI.Server.Components;

namespace rsm
{
    public class jklatch : LogicComponent{
        protected override void DoLogicUpdate(){
            if(Inputs[2].On){
                if(Inputs[0].On && Inputs[1].On){
                    Outputs[0].On = !Outputs[0].On;
                    Outputs[1].On = !Outputs[1].On;
                }else if(Inputs[0].On){
                    Outputs[0].On = true;
                    Outputs[1].On = false;
                }else if(Inputs[1].On){
                    Outputs[0].On = false;
                    Outputs[1].On = true;
                }
            }
            if(Inputs[3].On){
                Outputs[0].On = false;
                Outputs[1].On = true;
            }
        }
    }

    public class srlatch : LogicComponent{
        protected override void DoLogicUpdate(){
            if(Inputs[0].On){
                Outputs[0].On = true;
                Outputs[1].On = false;
            }
            if(Inputs[1].On){
                Outputs[0].On = false;
                Outputs[1].On = true;
            }
        }
    }

    public class tlatch : LogicComponent{
        protected override void DoLogicUpdate(){
            if(Inputs[1].On && Inputs[0].On){
                Outputs[0].On = !Outputs[0].On;
                Outputs[1].On = !Outputs[1].On;
            }
            if(Inputs[2].On){
                Outputs[0].On = false;
                Outputs[1].On = true;
            }
        }
    }

    public class dlatchr : LogicComponent{
        protected override void DoLogicUpdate(){
            if(Inputs[1].On){
                Outputs[0].On = Inputs[0].On;
                Outputs[1].On = !Inputs[0].On;
            }
            if(Inputs[2].On){
                Outputs[0].On = true;
                Outputs[1].On = false;
            }
            if(Inputs[3].On){
                Outputs[0].On = false;
                Outputs[1].On = true;
            }
        }
    }

    public class xnor : LogicComponent{
        protected override void DoLogicUpdate(){
            if(Inputs[0].On == Inputs[1].On){
                Outputs[0].On = true;
            }else{
                Outputs[0].On = false;
            }
        }
    }

    public class nor : LogicComponent{
        protected override void DoLogicUpdate(){
            Outputs[0].On = !(Inputs[0].On || Inputs[1].On);
        }
    }

    public class nand : LogicComponent{
        protected override void DoLogicUpdate(){
            Outputs[0].On = !(Inputs[0].On && Inputs[1].On);
        }
    }

    public class or : LogicComponent{
        protected override void DoLogicUpdate(){
            Outputs[0].On = Inputs[0].On || Inputs[1].On;
        }
    }

    public class controlled_inv : LogicComponent{
        protected override void DoLogicUpdate(){
            if(Inputs[1].On){
                Outputs[0].On = !Inputs[0].On;
            }else{
                Outputs[0].On=false;
            }
        }
    }

    public class controlled_buf : LogicComponent{
        protected override void DoLogicUpdate(){
            if(Inputs[1].On){
                Outputs[0].On = Inputs[0].On;
            }else{
                Outputs[0].On=false;
            }
        }
    }
}