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
    this.subscribe("input", "aDown", this.moveUp);
    this.subscribe("input", "sDown", this.moveDown);
    this.subscribe("input", "qDown", this.moveIn);
    this.subscribe("input", "wDown", this.moveOut);
  }

  moveIn() {
    console.log("move in");
    const translation = this.translation;
    translation[2] += -0.1;
    this.set({ translation });
  }

  moveOut() {
    console.log("move out");
    const translation = this.translation;
    translation[2] += 0.1;
    this.set({ translation });
  }

  moveUp() {
    console.log("move up");
    const translation = this.translation;
    translation[1] += -0.1;
    this.set({ translation });
  }

  moveDown() {
    console.log("move down");
    const translation = this.translation;
    translation[1] += 0.1;
    this.set({ translation });
  }

  moveLeft() {
    console.log("move left");
    const translation = this.translation;
    translation[0] += -0.1;
    this.set({ translation });
  }

  moveRight() {
    console.log("move right");
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
    console.log(JSON.stringify(options));
    this.test = TestActor.create({ translation: [3.25, 2.5, 0.5] });
  }
}
MyModelRoot.register("MyModelRoot");
