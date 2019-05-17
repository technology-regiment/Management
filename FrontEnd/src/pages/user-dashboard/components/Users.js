import { connect } from 'dva';
import { Table, Pagination, Popconfirm, Button } from 'antd';
import { routerRedux } from 'dva/router';
import styles from './Users.css';
import UserModal from './UserModal';

function Users({ dispatch, loading, data,user }) {
  function deleteHandler(Id) {
    dispatch({
      type: 'user-dashboard/remove',
      payload: Id,
    });
  }

  function pageChangeHandler(page) {
    dispatch({
      type: 'user-dashboard/fetch',
      payload: { page },
    });
  }
function editGetUserHandler(Id){
  dispatch({
    type: 'user-dashboard/getById',
    payload: Id,
  });
}
  function editHandler(Id, values) {
    const editValues = { Id, ...values };
    dispatch({
      type: 'user-dashboard/patch',
      payload: editValues,
    });
  }

  function createHandler(values) {
    dispatch({
      type: 'user-dashboard/create',
      payload: values,
    });
  }

  const columns = [
    {
      title: '用户姓名',
      dataIndex: 'Name',
      key: 'name',
    },
    {
      title: 'Operation',
      key: 'operation',
      render: (text, record) => (
        <span className={styles.operation}>
          <UserModal record={record} onOk={editHandler.bind(null, record.Id)}>
          <Button type="primary" onClick={editGetUserHandler.bind(null,record.Id)}>修改</Button>
          </UserModal>
          <Popconfirm title="确定删除?" onConfirm={deleteHandler.bind(null, record.Id)}>
          <Button type="danger">删除</Button>
          </Popconfirm>
        </span>
      ),
    },
  ];

  return (
    <div className={styles.normal}>
      <div>
        <div className={styles.create}>
          <UserModal record={{}} onOk={createHandler}>
            <Button type="primary">新增用户</Button>
          </UserModal>
        </div>
        <Table
          loading={loading}
          columns={columns}
          dataSource={data.Results}
          rowKey="Id"
          pagination={false}
        />
        <Pagination
          className="ant-table-pagination"
          total={data.Pagination.Total}
          current={data.Pagination.Current}
          pageSize={data.Pagination.PageSize}
          onChange={pageChangeHandler}
        />
      </div>
    </div>
  );
}

function mapStateToProps(state) {
  const { page, data ,user} = state['user-dashboard'];
  return {
    data,
    loading: state.loading.models['user-dashboard'],
  };
}

export default connect(mapStateToProps)(Users);
