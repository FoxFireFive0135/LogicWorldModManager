using LogicAPI.Server.Components;

namespace rsm
{
    public class sn74283 : LogicComponent
    {
        protected override void DoLogicUpdate()
        {
            //I don't feel like reassigning the pin-numbers, at least not right now.
            int a = 0;
            a += Inputs[1].On ? 1 : 0;
            a += Inputs[3].On ? 2 : 0;
            a += Inputs[5].On ? 4 : 0;
            a += Inputs[6].On ? 8 : 0;
            int b = 0;
            b += Inputs[0].On ? 1 : 0;
            b += Inputs[2].On ? 2 : 0;
            b += Inputs[4].On ? 4 : 0;
            b += Inputs[7].On ? 8 : 0;
            int c = Inputs[8].On ? 1 : 0;

            int n = a+b+c;

            for (int i = 0; i < 5; i++)
            {
                int bitValue = n & (1 << i);
                Outputs[i].On = bitValue > 0;
            }
        }
    }
    public class sn74245 : LogicComponent
    {
        protected override void DoLogicUpdate()
        {
            int a = 0;
            for(int x = 1; x<9; x++){
                a += Inputs[x].On ? 1<<x-1 : 0;
            }

            int b = 0;
            for(int x = 10; x<18; x++){
                b += Inputs[x].On ? 1<<x-10 : 0;
            }

            //A to B or B to A?
            if (Inputs[0].On){
                if(!Inputs[9].On){
                    io.output(8,15,a, Outputs);
                    io.output(0,7,0, Outputs);
                }else{
                    io.output(0,7,0, Outputs);
                    io.output(8,15,0, Outputs);
                }
            }else{
                if(!Inputs[9].On){
                    io.output(0,7,b, Outputs);
                    io.output(8,15,0, Outputs);
                }else{
                    io.output(0,7,0, Outputs);
                    io.output(8,15,0, Outputs);
                }
            }
        }
    }
    public class sn74173 : LogicComponent
    {
        //0 - Q1
        //1 - Q2
        //2 - Q3
        //3 - Q4

        //0 - M
        //1 - N
        //2 - CLK
        //3 - !G1
        //4 - !G2
        //8 - 4D
        //7 - 3D
        //6 - 2D
        //5 - 1D
        //9 - CLR

        int reg = 0; //our "register"

        protected override void DoLogicUpdate()
        {
            int data = 0;
            if(!Inputs[3].On && !Inputs[4].On){
                for(int x = 5; x<9; x++){
                    data += Inputs[x].On ? 1<<x-5 : 0;
                }
            }
            if(Inputs[2].On){
                reg = data;
            }
            if(Inputs[9].On){
                reg = 0;
            }

            if(!Inputs[0].On && !Inputs[1].On){
                io.output(0, 3, reg, Outputs);
            }else{
                io.output(0, 3, 0, Outputs);
            }
        }
    }
    public class sn74157 : LogicComponent
    {
        protected override void DoLogicUpdate()
        {
            //SELECT - 0
            //STROBE - 9
            //A1 - 1
            //B1 - 2
            //A2 - 3
            //B2 - 4
            //A3 - 5
            //B3 - 6
            //A4 - 7
            //B4 - 8
            //Y1 - 0
            //Y2 - 1
            //Y3 - 2
            //Y4 - 3

            //------

            //Y1
            if(!Inputs[9].On){
                if(Inputs[0].On){
                    Outputs[0].On = Inputs[2].On;
                }else{
                    Outputs[0].On = Inputs[1].On;
                }
            }else{
                Outputs[0].On = false;
            }
            //Y2
            if(!Inputs[9].On){
                if(Inputs[0].On){
                    Outputs[1].On = Inputs[4].On;
                }else{
                    Outputs[1].On = Inputs[3].On;
                }
            }else{
                Outputs[1].On = false;
            }
            //Y3
            if(!Inputs[9].On){
                if(Inputs[0].On){
                    Outputs[2].On = Inputs[6].On;
                }else{
                    Outputs[2].On = Inputs[5].On;
                }
            }else{
                Outputs[2].On = false;
            }
            //Y4
            if(!Inputs[9].On){
                if(Inputs[0].On){
                    Outputs[3].On = Inputs[8].On;
                }else{
                    Outputs[3].On = Inputs[7].On;
                }
            }else{
                Outputs[3].On = false;
            }
        }
    }
    public class sn74139 : LogicComponent
    {
        protected override void DoLogicUpdate(){
            //G1 - 0
            //G2 - 3
            //A1 - 1
            //A2 - 4
            //B1 - 2
            //B2 - 5
            //1Y0 - 0
            //1Y1 - 1
            //1Y2 - 2
            //1Y3 - 3
            //2Y0 - 4
            //2Y1 - 5
            //2Y2 - 6
            //2Y3 - 7
            int a = 0;
            a += Inputs[1].On ? 1 : 0;
            a += Inputs[2].On ? 2 : 0;
            int b = 0;
            b += Inputs[4].On ? 1 : 0;
            b += Inputs[5].On ? 2 : 0;

            if(!Inputs[0].On){
                io.output_al(0,3, 1<<a,Outputs);
            }else{
                io.output_al(0,3,0,Outputs);
            }
            if(!Inputs[3].On){
                io.output_al(4,7, 1<<b,Outputs);
            }else{
                io.output_al(4,7,0,Outputs);
            }
        }
    }
    public class sn74138 : LogicComponent
    {
        protected override void DoLogicUpdate(){
            int abc = 0;
            for(int x = 0; x<3; x++){
                abc += Inputs[x].On ? 1<<x : 0;
            }
            if(!Inputs[3].On && !Inputs[4].On && Inputs[5].On){
                io.output_al(0,7, 1<<abc, Outputs);
            }else{
                io.output_al(0,7,0,Outputs);
            }
        }
    }
    public class sn74107 : LogicComponent
    {
        //1J - 0
        //1q - 0
        //1Q - 1
        //1K - 1
        //2Q - 2
        //2q - 3
        //1clr - 2
        //1CLK - 3
        //2K - 4
        //2clr - 5
        //2CLK - 6
        //2J - 7

        protected override void DoLogicUpdate(){
            if(Inputs[3].On){
                if(Inputs[0].On && Inputs[1].On){
                    Outputs[1].On = !Outputs[1].On;
                    Outputs[0].On = !Outputs[0].On;
                }else if(Inputs[0].On){
                    Outputs[1].On = true;
                    Outputs[0].On = false;
                }else if(Inputs[1].On){
                    Outputs[1].On = false;
                    Outputs[0].On = true;
                }
            }
            if(Inputs[2].On){
                Outputs[1].On = false;
                Outputs[0].On = true;
            }

            //--------------------------------------------------------------

            if(Inputs[6].On){
                if(Inputs[7].On && Inputs[4].On){
                    Outputs[3].On = !Outputs[3].On;
                    Outputs[2].On = !Outputs[2].On;
                }else if(Inputs[7].On){
                    Outputs[3].On = true;
                    Outputs[2].On = false;
                }else if(Inputs[4].On){
                    Outputs[3].On = false;
                    Outputs[2].On = true;
                }
            }
            if(Inputs[5].On){
                Outputs[3].On = false;
                Outputs[2].On = true;
            }
        }
    }
}