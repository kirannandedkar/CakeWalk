// This is the base model
export class BaseModel {
    constructor() { }

    // create Object Self define object from the data.
    createObject(otherModel: any) {
      for (const key of Object.keys(otherModel)) {
        if (!(typeof (this[key]) === 'undefined')) {
          this[key] = otherModel[key];
        }
      }
      return this;
    }

  }
