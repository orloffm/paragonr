import { ActionType } from "typesafe-actions";

import * as loginActions from "./types";

export type AllLoginActions = ActionType<typeof loginActions>;
