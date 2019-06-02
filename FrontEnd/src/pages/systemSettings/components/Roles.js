import { connect } from 'dva';
import { Component } from 'react';
import { Table, Pagination, Popconfirm, Button ,Input,Row,Col} from 'antd';
import { routerRedux } from 'dva/router';
import styles from './Users.css';
import RoleModal from './RoleModal';

@connect(({ role ,loading }) => ({
  role,
  loading: loading.effects['role/fetch'],
}))

class Roles extends Component {

  state = {
    filter: {},
    pagination: {
      orderProperty: 'Name',
      ascending: false,
      pageNumber: 1,
      pageSize: 10,
    },
  };

  getByPage = () => {
    const { filter, pagination } = this.state;
    this.props.dispatch({
      type: 'role/fetch',
      payload: {
        filter,
        ...pagination,
      },
    });
  };


  componentDidMount() {
    this.getByPage();
  }

  createHandler = ( values) => {
    const { dispatch } = this.props;
    dispatch({
      type: 'role/create',
      payload: values,
     
    });
  };

   pageChangeHandler=(page)=> {
    dispatch({
      type: 'user-dashboard/fetch',
      payload: { page },
    });
  }
  render() {
    const { Search } = Input
        const {role,loading}=this.props;
        const {data}=role;
        const columns = [
            {
              title: '角色名称',
              dataIndex: 'Name',
              key: 'name',
            },
            {
                title: '角色描述',
                dataIndex: 'Description',
                key: 'description', 
            },
          ];
        

        return (
            <div className={styles.normal}>
            <div>
            <div>
              <Row >
                <Col span={4}>
                  <Search
                  />
                </Col>
              </Row>
            </div>
              <div className={styles.create}>
                <RoleModal record={{}} onOk={this.createHandler}>
                  <Button type="primary">新增角色</Button>
                </RoleModal>
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
                onChange={this.pageChangeHandler}
        />
            </div>
          </div>
    );
  }
}

export default Roles;

