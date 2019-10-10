import { createStandardAction } from "./node_modules/typesafe-actions";
import { AuthSetPayload } from "./AuthSetPayload";

export const AUTH_SET = "AUTH_SET";
export const AUTH_CLEAR = "AUTH_CLEAR";

export const authSet = createStandardAction(AUTH_SET)<AuthSetPayload>();
export const authClear = createStandardAction(AUTH_CLEAR)();