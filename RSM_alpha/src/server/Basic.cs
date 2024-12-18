using LogicAPI.Server.Components;

namespace rsm
{
    public class SN7408 : LogicComponent
    {
        protected override void DoLogicUpdate()
        {
            Outputs[0].On = (Inputs[0].On && Inputs[1].On);
            Outputs[1].On = (Inputs[2].On && Inputs[3].On);
            Outputs[2].On = (Inputs[4].On && Inputs[5].On);
            Outputs[3].On = (Inputs[6].On && Inputs[7].On);
        }
    }

    public class SN7400 : LogicComponent
    {
        protected override void DoLogicUpdate()
        {
            Outputs[0].On = !(Inputs[0].On && Inputs[1].On);
            Outputs[1].On = !(Inputs[2].On && Inputs[3].On);
            Outputs[2].On = !(Inputs[4].On && Inputs[5].On);
            Outputs[3].On = !(Inputs[6].On && Inputs[7].On);
        }
    }

    public class SN7404 : LogicComponent
    {
        protected override void DoLogicUpdate()
        {
            Outputs[0].On = !Inputs[0].On;
            Outputs[1].On = !Inputs[1].On;
            Outputs[2].On = !Inputs[2].On;
            Outputs[3].On = !Inputs[3].On;
            Outputs[4].On = !Inputs[4].On;
            Outputs[5].On = !Inputs[5].On;
        }
    }

    public class SN7402 : LogicComponent
    {
        protected override void DoLogicUpdate()
        {
            Outputs[0].On = !(Inputs[0].On || Inputs[1].On);
            Outputs[1].On = !(Inputs[2].On || Inputs[3].On);
            Outputs[2].On = !(Inputs[4].On || Inputs[5].On);
            Outputs[3].On = !(Inputs[6].On || Inputs[7].On);
        }
    }

    public class SN7432 : LogicComponent
    {
        protected override void DoLogicUpdate()
        {
            Outputs[0].On = Inputs[0].On || Inputs[1].On;
            Outputs[1].On = Inputs[2].On || Inputs[3].On;
            Outputs[2].On = Inputs[4].On || Inputs[5].On;
            Outputs[3].On = Inputs[6].On || Inputs[7].On;
        }
    }

    public class SN7486 : LogicComponent
    {
        protected override void DoLogicUpdate()
        {
            Outputs[0].On = Inputs[0].On ^ Inputs[1].On;
            Outputs[1].On = Inputs[2].On ^ Inputs[3].On;
            Outputs[2].On = Inputs[4].On ^ Inputs[5].On;
            Outputs[3].On = Inputs[6].On ^ Inputs[7].On;
        }
    }

    public class SN7447 : LogicComponent
    {
        static uint[] o = new uint[]{63,6,91,79,102,109,125,7,127,103,88,76,98,105,120,0};
        protected override void DoLogicUpdate()
        {
            //4 - lt
            //5 bi rbo
            //6 rbi

            int n = 0;

            if(Inputs[4].On && Inputs[5].On){
                n += Inputs[0].On ? 1 : 0;
                n += Inputs[1].On ? 2 : 0;
                n += Inputs[2].On ? 4 : 0;
                n += Inputs[3].On ? 8 : 0;
            }else if(!Inputs[4].On && Inputs[5].On){
                n=8;
            }else{
                n=0;
            }


            var outputNumber = o[n];

            for (int i = 0; i < 7; i++)
            {
                uint bitValue = outputNumber & (1u << i);
                this.Outputs[i].On = bitValue > 0;
            }


        }
    }

    public class fulladder : LogicComponent
    {
        protected override void DoLogicUpdate()
        {
            int n = 0;
            n += Inputs[0].On ? 1 : 0;
            n += Inputs[1].On ? 1 : 0;
            n += Inputs[2].On ? 1 : 0;

            for (int i = 0; i < 2; i++)
            {
                uint bitValue = (uint)n & (1u << i);
                this.Outputs[i].On = bitValue > 0;
            }
        }
    }

    public class halfadder : LogicComponent
    {
        protected override void DoLogicUpdate()
        {
            int n = 0;
            n += Inputs[0].On ? 1 : 0;
            n += Inputs[1].On ? 1 : 0;

            for (int i = 0; i < 2; i++)
            {
                uint bitValue = (uint)n & (1u << i);
                this.Outputs[i].On = bitValue > 0;
            }
        }
    }
}