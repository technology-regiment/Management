import * as rolesService from '@/services/role';

export default {
  namespace: 'role',
  state: {
    data: {
      Results: [],
      Pagination: {},
    },
    filter: {},
    pagination: {
      orderProperty: 'Name',
      ascending: false,
      pageNumber: 1,
      pageSize: 10,
    },
  },
  reducers: {
    save(state, action) {
      return {
        ...state,
        data: action.payload,
      };
    },
  },
 
  effects: {
    *fetch({ payload }, { call, put }) {
      const response = yield call(rolesService.fetch, payload);
      yield put({
        type: 'save',
        payload: response,
      });
    },
 

    *create({ payload: values }, { call, put, select }) {
      yield call(rolesService.create, values);
      const filter = yield select(state => state['user-dashboard'].filter);
      const pagination = yield select(state => state['user-dashboard'].pagination);
      yield put({ type: 'fetch', payload: { filter, ...pagination } });
    },

    *patch({ payload: editValues }, { call, put, select }) {
      yield call(rolesService.edit, editValues);
      const filter = yield select(state => state['user-dashboard'].filter);
      const pagination = yield select(state => state['user-dashboard'].pagination);
      yield put({ type: 'fetch', payload: { filter, ...pagination } });
    },

    *remove({ payload: Id }, { call, put, select }) {
      yield call(rolesService.remove, Id);
      const filter = yield select(state => state['user-dashboard'].filter);
      const pagination = yield select(state => state['user-dashboard'].pagination);
      yield put({ type: 'fetch', payload: { filter, ...pagination } });
    },
  },
};