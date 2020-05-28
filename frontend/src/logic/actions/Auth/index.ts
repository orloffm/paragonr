import { ActionType } from "typesafe-actions";
import * as authActions from "./types";

export type AllAuthActions = ActionType<typeof authActions>;
