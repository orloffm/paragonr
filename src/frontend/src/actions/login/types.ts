import { createStandardAction } from "typesafe-actions";

const INCREMENT = "INCREMENT";
const DECREMENT = "DECREMENT";
const RESET = "RESET";

export const increment = createStandardAction(INCREMENT)();
export const decrement = createStandardAction(DECREMENT)();
export const reset = createStandardAction(RESET)();
