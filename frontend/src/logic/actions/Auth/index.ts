import { ActionType } from "./node_modules/typesafe-actions";

import * as authActions from "./types";

export type AllAuthActions = ActionType<typeof authActions>;
