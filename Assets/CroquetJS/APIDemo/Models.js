import { Actor, mix, AM_Spatial } from "@croquet/worldcore-kernel";
import { GameModelRoot } from "@croquet/game-models";

class TestActor extends mix(Actor).with(AM_Spatial) {
  get gamePawnType() {
    return "basicSphere";
  }

  init(options) {
    super.init(options);
    this.subscribe("input", "zDown", this.moveLeft);
    this.subscribe("input", "xDown", this.moveRight);
  }

  moveLeft() {
    const translation = this.translation;
    translation[0] += -0.1;
    this.set({ translation });
  }

  moveRight() {
    const translation = this.translation;
    translation[0] += 0.1;
    this.set({ translation });
  }
}
TestActor.register("TestActor");

export class MyModelRoot extends GameModelRoot {
  init(options) {
    super.init(options);
    console.log("Start model root!");
    this.test = TestActor.create({ translation: [3.25, 2.5, 0.5] });
  }
}
MyModelRoot.register("MyModelRoot");
