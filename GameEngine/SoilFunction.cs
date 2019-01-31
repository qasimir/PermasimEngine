using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.GameEngine {
    public abstract class SoilFunction : MonoBehaviour {
        public abstract float f(float t);

    }
}
