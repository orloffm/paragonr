import { ActionType } from "./node_modules/typesafe-actions";

import * as loginActions from "./types";

export type AllLoginActions = ActionType<typeof loginActions>;
