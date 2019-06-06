import { routerRedux } from 'dva/router';

import { setAuthority } from '@/utils/authority';
import { reloadAuthorized } from '@/utils/Authorized';
import { getPageQuery } from '@/utils/utils';
import * as loginService from './service';

export default {
  namespace: 'userLogin',

  state: {
    status: undefined,
  },

  effects: {
    *login({ payload }, { put,call }) {
      const loginUserInfo = yield call(loginService.login, payload);
      const VerificationTokenInfo= yield call(loginService.verification, {AuthenticationToken: loginUserInfo.AuthenticationToken});
      yield put({
        type: 'changeLoginStatus',
        payload: loginUserInfo,
      });
      if (loginUserInfo.Id === VerificationTokenInfo.Id) {
        reloadAuthorized();
        const urlParams = new URL(window.location.href);
        const params = getPageQuery();
        let { redirect } = params;
        if (redirect) {
          const redirectUrlParams = new URL(redirect);
          if (redirectUrlParams.origin === urlParams.origin) {
            redirect = redirect.substr(urlParams.origin.length);
            if (redirect.match(/^\/.*#/)) {
              redirect = redirect.substr(redirect.indexOf('#') + 1);
            }
          } else {
            redirect = null;
          }
        }
        yield put(routerRedux.replace(redirect || '/welcome'));
        window.location.reload();
      }
        }, 
  },

  reducers: {
    changeLoginStatus(state, { payload }) {
      setAuthority(payload);
      return {
        ...state,
        status: true,
        
      };
    },
  },
};
